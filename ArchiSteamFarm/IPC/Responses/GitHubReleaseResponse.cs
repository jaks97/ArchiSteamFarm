﻿//     _                _      _  ____   _                           _____
//    / \    _ __  ___ | |__  (_)/ ___| | |_  ___   __ _  _ __ ___  |  ___|__ _  _ __  _ __ ___
//   / _ \  | '__|/ __|| '_ \ | |\___ \ | __|/ _ \ / _` || '_ ` _ \ | |_  / _` || '__|| '_ ` _ \
//  / ___ \ | |  | (__ | | | || | ___) || |_|  __/| (_| || | | | | ||  _|| (_| || |   | | | | | |
// /_/   \_\|_|   \___||_| |_||_||____/  \__|\___| \__,_||_| |_| |_||_|   \__,_||_|   |_| |_| |_|
// 
// Copyright 2015-2019 Łukasz "JustArchi" Domeradzki
// Contact: JustArchi@JustArchi.net
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace ArchiSteamFarm.IPC.Responses {
	public sealed class GitHubReleaseResponse {
		/// <summary>
		///     Changelog of the release rendered in HTML.
		/// </summary>
		[JsonProperty(Required = Required.Always)]
		[Required]
		public readonly string ChangelogHTML;

		/// <summary>
		///     Date of the release.
		/// </summary>
		[JsonProperty(Required = Required.Always)]
		[Required]
		public readonly DateTime ReleasedAt;

		/// <summary>
		///     Boolean value that specifies whether the build is stable or not (pre-release).
		/// </summary>
		[JsonProperty(Required = Required.Always)]
		[Required]
		public readonly bool Stable;

		/// <summary>
		///     Version of the release.
		/// </summary>
		[JsonProperty(Required = Required.Always)]
		[Required]
		public readonly string Version;

		internal GitHubReleaseResponse([NotNull] GitHub.ReleaseResponse releaseResponse) {
			if (releaseResponse == null) {
				throw new ArgumentNullException(nameof(releaseResponse));
			}

			ChangelogHTML = releaseResponse.ChangelogHTML;
			ReleasedAt = releaseResponse.PublishedAt;
			Stable = !releaseResponse.IsPreRelease;
			Version = releaseResponse.Tag;
		}
	}
}
