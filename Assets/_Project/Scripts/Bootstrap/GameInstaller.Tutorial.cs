using Dreamy.Tutorial;

namespace Dreamy.Template
{
    public sealed partial class GameInstaller
    {
        private ITutorialService tutorialService;
        private void InstallTutorial()
        {
            // TrackFeatureInstallation restores any previous registration during reverse teardown.
            TrackFeatureInstallation<ITutorialService>(() => tutorialService = TutorialInstaller.Install(
                dataConfig.GetTable<TutorialCatalogConfig>(), datasave, "bus-fever.tutorial"));
        }
    }
}
