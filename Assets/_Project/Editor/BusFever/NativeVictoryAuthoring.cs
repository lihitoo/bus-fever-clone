using Spine.Unity;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Coffee.UIExtensions;
using System.Linq;

namespace Dreamy.Template.Editor
{
    public static class NativeVictoryAuthoring
    {
        public static string Build()
        {
            var alphaShader = Shader.Find("BusFever/UI/SourceParticleAlpha");
            if (alphaShader == null || ShaderUtil.ShaderHasError(alphaShader))
                throw new System.InvalidOperationException("Source particle alpha shader must import and compile before binding.");
            var data = AssetDatabase.LoadAssetAtPath<SkeletonDataAsset>(RecoveredAssetMigration.Root + "/MonoBehaviour/victory_SkeletonData.asset");
            foreach (var atlas in data.atlasAssets)
            {
                foreach (var atlasMaterial in ((SpineAtlasAsset)atlas).Materials)
                {
                    atlasMaterial.shader = Shader.Find("Spine/Skeleton");
                    EditorUtility.SetDirty(atlasMaterial);
                    AssetDatabase.SaveAssetIfDirty(atlasMaterial);
                }
            }
            data.Clear();
            var skeleton = data.GetSkeletonData(false);
            if (skeleton == null || skeleton.FindAnimation("jump") == null || skeleton.FindAnimation("idle") == null)
                throw new System.InvalidOperationException("Victory Spine data must expose source jump and idle animations.");
            const string materialPath = "Assets/_Project/Art/BusFever/UI/VictorySpine.mat";
            var material = AssetDatabase.LoadAssetAtPath<Material>(materialPath);
            if (material == null)
            {
                material = new Material(Shader.Find("Spine/SkeletonGraphic"));
                AssetDatabase.CreateAsset(material, materialPath);
            }
            const string path = "Assets/_Project/Prefabs/Panel/VictoryPanel.prefab";
            var root = PrefabUtility.LoadPrefabContents(path);
            try
            {
                var all = root.transform.Find("All_Empty");
                all.localScale = Vector3.one * .88f;
                ((RectTransform)all).anchoredPosition = new Vector2(0,-80);
                ((RectTransform)all.Find("Gold_Img")).anchoredPosition = new Vector2(0,-10);
                var gold = all.Find("Gold_Img").GetComponent<Image>();
                var previousArt = gold.transform.Find("GoldArt");
                if (previousArt != null) Object.DestroyImmediate(previousArt.gameObject);
                var goldArt = new GameObject("GoldArt", typeof(RectTransform), typeof(Image));
                goldArt.transform.SetParent(gold.transform, false);
                goldArt.transform.SetAsFirstSibling();
                var goldRect = (RectTransform)goldArt.transform;
                goldRect.sizeDelta = ((RectTransform)gold.transform).sizeDelta;
                goldRect.localScale = Vector3.one * .8f;
                goldRect.sizeDelta = new Vector2(goldRect.sizeDelta.x, goldRect.sizeDelta.y * .75f);
                goldRect.anchoredPosition = new Vector2(0,12);
                goldArt.GetComponent<Image>().sprite = gold.sprite;
                goldArt.GetComponent<Image>().raycastTarget = false;
                gold.enabled = false;
                var next = (RectTransform)all.Find("Btn_Group/Yellow_Button");
                next.anchoredPosition = new Vector2(next.anchoredPosition.x,-13);
                // Linear rendering needs a stronger cover to match the source's gamma-space dark result.
                root.transform.Find("ModalMask").GetComponent<Image>().color = new Color(0,0,0,.98f);
                const string nextMaterialPath = "Assets/_Project/Art/BusFever/UI/VictoryNextText.mat";
                var nextMaterial = AssetDatabase.LoadAssetAtPath<Material>(nextMaterialPath);
                if (nextMaterial == null)
                {
                    nextMaterial = new Material(next.GetComponentInChildren<TMPro.TMP_Text>(true).fontSharedMaterial);
                    AssetDatabase.CreateAsset(nextMaterial,nextMaterialPath);
                }
                nextMaterial.SetColor("_OutlineColor",new Color(.48f,.25f,.08f));
                nextMaterial.SetColor("_UnderlayColor",new Color(.48f,.25f,.08f));
                EditorUtility.SetDirty(nextMaterial);AssetDatabase.SaveAssetIfDirty(nextMaterial);
                foreach(var label in next.GetComponentsInChildren<TMPro.TMP_Text>(true)) label.fontSharedMaterial=nextMaterial;
                var person = all.Find("Person_Control"); person.gameObject.SetActive(true);
                Bind(person.Find("PersonJump_Spine").gameObject, data, material, "jump", false);
                Bind(person.Find("PersonIdle_Spine").gameObject, data, material, "idle", true);
                var animator = all.GetComponent<Animator>();
                if (animator == null) animator = all.gameObject.AddComponent<Animator>();
                animator.runtimeAnimatorController = AssetDatabase.LoadAssetAtPath<RuntimeAnimatorController>(RecoveredAssetMigration.Root + "/AnimatorController/Effect_VictoryPanel.controller");
                animator.updateMode = AnimatorUpdateMode.UnscaledTime;
                BindFireworks(all.Find("Fireworks"));
                BindBalance(root);
                PrefabUtility.SaveAsPrefabAsset(root, path);
            }
            finally { PrefabUtility.UnloadPrefabContents(root); }
            return "Source Spine3.8 jump/idle and recovered Victory entrance controller bound to existing panel.";
        }

        private static void BindBalance(GameObject root)
        {
            var previous = root.transform.Find("VictoryBalanceSafeArea");
            if (previous != null) Object.DestroyImmediate(previous.gameObject);
            var safe = new GameObject("VictoryBalanceSafeArea",typeof(RectTransform),typeof(Dreamy.UI.SafeArea));
            safe.transform.SetParent(root.transform,false);
            var safeRect=(RectTransform)safe.transform;
            safeRect.anchorMin=Vector2.zero;safeRect.anchorMax=Vector2.one;safeRect.sizeDelta=Vector2.zero;
            var coin=Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/_Project/Art/BusFever/UI/Btn_Gold.prefab"),safe.transform,false);
            var rect=(RectTransform)coin.transform;
            rect.anchorMin=rect.anchorMax=new Vector2(0,1);rect.anchoredPosition=new Vector2(230,-65);
            rect.localScale=Vector3.one*.85f;
            foreach(var graphic in coin.GetComponentsInChildren<Graphic>(true))graphic.raycastTarget=false;
            var text=coin.GetComponentInChildren<TMPro.TMP_Text>(true);
            var icon=coin.GetComponentsInChildren<Image>(true).First(image=>image.name=="Gold_Img"&&image.sprite!=null);
            foreach(var image in coin.GetComponentsInChildren<Image>(true))
                if(image.name=="Add_Img")image.gameObject.SetActive(false);
            var panel=new SerializedObject(root.GetComponent<Dreamy.Template.Gameplay.VictoryPanel>());
            panel.FindProperty("balanceText").objectReferenceValue=text;
            panel.FindProperty("balanceTarget").objectReferenceValue=icon.rectTransform;
            panel.FindProperty("coinIcon").objectReferenceValue=icon.sprite;
            panel.ApplyModifiedPropertiesWithoutUndo();
        }

        private static void BindFireworks(Transform container)
        {
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(RecoveredAssetMigration.Root + "/busjam/game/effect/prefabs/Effect_Fireworks.prefab");
            container.gameObject.SetActive(true);
            foreach (Transform anchor in container)
            {
                // The source entrance clip owns these anchors. Each panel owns and destroys its particle children.
                var existing = anchor.Find("SourceFireworks");
                var effect = existing != null ? existing.gameObject : Object.Instantiate(prefab, anchor, false);
                effect.name = "SourceFireworks";
                var rect = (RectTransform)effect.transform;
                rect.anchoredPosition = Vector2.zero;
                foreach (var ui in effect.GetComponentsInChildren<UIParticle>(true))
                {
                    ui.autoScalingMode = UIParticle.AutoScalingMode.None;
                    // The extracted source host initializes this zero-scale particle root.
                    // None mode keeps that scale, so restore it explicitly before baking.
                    ui.transform.localScale = Vector3.one;
                    // Source sizes/speeds are already authored in Canvas pixels (e.g. 550px burst).
                    ui.scale = 1;
                    ui.raycastTarget = false;
                    ui.RefreshParticles();
                }
                foreach (var particle in effect.GetComponentsInChildren<ParticleSystem>(true))
                {
                    var main = particle.main; main.useUnscaledTime = true;
                }
                foreach (var renderer in effect.GetComponentsInChildren<ParticleSystemRenderer>(true))
                    foreach (var material in renderer.sharedMaterials.Concat(new[] { renderer.trailMaterial }).Distinct())
                    {
                        if (material == null) continue;
                        var properties = new SerializedObject(material).FindProperty("m_SavedProperties.m_TexEnvs");
                        Texture texture = null;
                        for (int i = 0; i < properties.arraySize; i++)
                        {
                            var entry = properties.GetArrayElementAtIndex(i);
                            var key = entry.FindPropertyRelative("first").stringValue;
                            var value = entry.FindPropertyRelative("second.m_Texture").objectReferenceValue as Texture;
                            if ((key == "_MainTex" || key == "_BaseMap") && value != null) texture = value;
                        }
                        // UI/Default declares PerRendererData: Coffee clears the renderer texture,
                        // which replaced trail alpha textures with white. Use the package shader's alpha variant.
                        material.shader = Shader.Find(material.name.Contains("Alp") ? "BusFever/UI/SourceParticleAlpha" : "UI/Additive");
                        material.SetTexture("_MainTex", texture);
                        material.SetColor("_Color", Color.white);
                        EditorUtility.SetDirty(material); AssetDatabase.SaveAssetIfDirty(material);
                    }
            }
        }

        private static void Bind(GameObject node, SkeletonDataAsset data, Material material, string animation, bool loop)
        {
            var graphic = node.GetComponent<SkeletonGraphic>();
            if (graphic == null) graphic = node.AddComponent<SkeletonGraphic>();
            graphic.skeletonDataAsset = data;
            graphic.material = material;
            graphic.raycastTarget = false;
            graphic.startingAnimation = animation;
            graphic.startingLoop = loop;
            graphic.unscaledTime = true;
            graphic.Initialize(true);
        }
    }
}
