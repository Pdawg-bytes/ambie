﻿using Windows.ApplicationModel.Resources;

namespace AmbientSounds.Converters
{
    /// <summary>
    /// Static class used to localize strings.
    /// </summary>
    public static class LocalizationConverter
    {
        /// <summary>
        /// Attempts to localize a sound's name.
        /// </summary>
        /// <param name="value">The <see cref="Models.Sound.Name"/> property.</param>
        /// <returns>A localized string of the sound if a localization exists.</returns>
        public static string ConvertSoundName(string value)
        {
            var resourceLoader = ResourceLoader.GetForCurrentView();
            if (value is string soundName)
            {
                var translatedName = resourceLoader.GetString("Sound-" + soundName);
                return string.IsNullOrWhiteSpace(translatedName)
                    ? soundName
                    : translatedName;
            }
            else
            {
                return resourceLoader.GetString("ReadyToPlayText");
            }
        }

        /// <summary>
        /// Returns localized words for whether the player
        /// button can be paused or played.
        /// </summary>
        /// <param name="isPaused">Current state of the player.</param>
        public static string ConvertPlayerButtonState(bool isPaused)
        {
            var resourceLoader = ResourceLoader.GetForCurrentView();
            return isPaused ? resourceLoader.GetString("PlayerPlayText") : resourceLoader.GetString("PlayerPauseText");
        }

        public static string SoundStatus(bool isCurrentlyPlaying)
        {
            var resourceLoader = ResourceLoader.GetForCurrentView();
            if (isCurrentlyPlaying)
            {
                return resourceLoader.GetString("Playing");
            }
            else
            {
                return resourceLoader.GetString("Paused");
            }
        }

        /// <summary>
        /// Returns localized phrase for online sound object
        /// in a list view.
        /// </summary>
        /// <param name="name">Name of the sound.</param>
        /// <param name="canDownload">Whether or not the sound can be downloaded or is already downloaded.</param>
        /// <remarks>
        /// Generally used for AutomationProperties.Name.
        /// </remarks>
        public static string ConvertOnlineSoundListViewName(string name, bool canDownload)
        {
            var resourceLoader = ResourceLoader.GetForCurrentView();
            var result = name + ". ";
            result += canDownload 
                ? resourceLoader.GetString("CanDownload") 
                : resourceLoader.GetString("AlreadyDownloaded");

            return result;
        }
    }
}
