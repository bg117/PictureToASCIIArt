# PictureToASCIIArt

Converts images to ASCII art

## How to Use

### Flags

`--render-file:<image-file>` : renders `<image-file>` as ASCII.

#### Optional flags

`--to:<file-path>` : Writes the ASCII art to `<file-path>`.  
`--max-height:<int>` : Sets `<int>` as the maximum height of the output ASCII art, in characters-height.  
`--max-width:<int>` : Sets `<int>` as the maximum width of the output ASCII art, in characters-width.

##### Illustration of characters-width and characters-height

[Illustration](/images/illustration-of-char-width-and-length.png)

#### Example usage

`PictureToASCIIArt.exe --render-file:image.jpg --to:ascii.txt --max-width:200 --max-height:100`  
`PictureToASCIIArt.exe --render-file:image.jpg --to:ascii.txt --max-height:75`

<sup>
Copyright © The OpenCode Team 2021

Released under the MIT License
</sup>
