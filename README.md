# PictureToASCIIArt
Converts images to ASCII art

## How to Use
### Options
`--render-file:<image-file>` : renders `<image-file>` as ASCII.

`--to:<file-path>` : **Optional.** Writes the ASCII to `<file-path>`. To be used in combination with `--render-file:`.

#### Example usage
`PictureToASCIIArt.exe --render-file:image.jpg --to:ascii.txt`

`PictureToASCIIArt` only works with Windows due to its usage of the `System.Drawing.Common` namespace.

<sup>
Copyright © The OpenCode Team 2021

Released under the MIT License
</sup>
