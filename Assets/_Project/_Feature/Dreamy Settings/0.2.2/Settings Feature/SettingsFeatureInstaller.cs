using System;
using Dreamy.Audio;
using Dreamy.Settings;
using Dreamy.UI;

namespace Dreamy.Feature.Settings.Integration
{
    /// <summary>Production composition entry point for the supplied Settings views.</summary>
    public static class SettingsFeatureInstaller
    {
        public static ISettingsService Install(PanelPresenterFactory factory, IAudioService audio, Action openRateUs,
            ISettingsPlatformGateway platform = null, ISettingsHapticsGateway haptics = null,
            ISettingsReviewGateway review = null, ISettingsLanguageGateway language = null)
        {
            if (factory == null) throw new ArgumentNullException(nameof(factory));
            if (openRateUs == null) throw new ArgumentNullException(nameof(openRateUs));
            return Install(factory, SettingsInstaller.Install(audio, platform, haptics, review, language), openRateUs);
        }

        public static ISettingsService Install(PanelPresenterFactory factory, ISettingsService service, Action openRateUs, Action restart = null)
        {
            if (factory == null) throw new ArgumentNullException(nameof(factory));
            if (service == null) throw new ArgumentNullException(nameof(service));
            if (openRateUs == null) throw new ArgumentNullException(nameof(openRateUs));
            factory.Register<SettingsPanel>(view => new SettingsPanelPresenter(new SettingsPresenter(service, view, openRateUs), view, restart));
            factory.Register<RateUsPanel>(view => new RateUsPresenter(service, view));
            return service;
        }
    }
}
