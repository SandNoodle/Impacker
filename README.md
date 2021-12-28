<div id="top"></div>

<!-- PROJECT SHIELDS -->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/SandNoodle/Impacker">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>

<h3 align="center">Impacker</h3>

  <p align="center">
    CLI Image processing tool for games.
    <br />
    <a href="https://github.com/SandNoodle/Impacker"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/SandNoodle/Impacker">View Demo</a>
    ·
    <a href="https://github.com/SandNoodle/Impacker/issues">Report Bug</a>
    ·
    <a href="https://github.com/SandNoodle/Impacker/issues">Request Feature</a>
  </p>
</div>

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->
## About The Project

Due to time consuming process of creating Playstation I styled textures. I've decided to create this tool that can simplify this proces from few minutes to few seconds.

<p align="right">(<a href="#top">back to top</a>)</p>

### Built With

* [.NET 5](https://dotnet.microsoft.com/en-us/)
* [ImageSharp](https://sixlabors.com/products/imagesharp/)
* [CommandLineParser](https://github.com/commandlineparser/commandline)

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- GETTING STARTED -->
## Getting Started

### Prerequisites

Make sure that you have Dotnet CLI installed on your system.

### Installation

1. Clone the repo.
   ```sh
    git clone https://github.com/SandNoodle/Impacker.git
   ```
2. CD into Source directory
   ```sh
	cd Source/
   ```
3. Pack Impacker using dotnet CLI.
   ```sh
    dotnet pack
   ```
4. Either install or update tool. 
   ```sh
   # Install
	dotnet tool install --global --add-source ../NuGet-Build Impacker
   
   # Update
    dotnet tool update --global --add-source ../NuGet-Build Impacker
   ```
<p align="right">(<a href="#top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

Using this CLI tool boils down to invoking:
```sh
Impacker --help
```

**Example:**
To generate `TGA` textures of sizes: `128, 64, 48, 32` from all the textures inside current input directory type:

```sh
	Impacker -s 128 64 48 32 -t TGA
```

Generated textures will be located inside `/out` directory.

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- ROADMAP -->
## Roadmap

See the [open issues](https://github.com/SandNoodle/Impacker/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

* [AmbientCG](https://ambientcg.com/)

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/SandNoodle/Impacker.svg?style=for-the-badge
[contributors-url]: https://github.com/SandNoodle/Impacker/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/SandNoodle/Impacker.svg?style=for-the-badge
[forks-url]: https://github.com/SandNoodle/Impacker/network/members
[stars-shield]: https://img.shields.io/github/stars/SandNoodle/Impacker.svg?style=for-the-badge
[stars-url]: https://github.com/SandNoodle/Impacker/stargazers
[issues-shield]: https://img.shields.io/github/issues/SandNoodle/Impacker.svg?style=for-the-badge
[issues-url]: https://github.com/SandNoodle/Impacker/issues
[license-shield]: https://img.shields.io/github/license/SandNoodle/Impacker.svg?style=for-the-badge
[license-url]: https://github.com/SandNoodle/Impacker/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555