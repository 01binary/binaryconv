# Mono Image to Binary Array Converter

This command line utility will load most common image formats and output a C/C++ header file that can be used in Arduino or similar platforms to draw this as a bitmap from a byte array.

Usage:
```
binaryconv imagepath [outputname].
```

So basically given a monochrome image like this:

![sample](switchback-mono.png)

...you get output like:

```
#define switchback_width 128
#define switchback_height 9

const uint8_t PROGMEM switchback_data[] = {
    B00111111, B11110000, B10000110, B00010010, B00000100, B11111110, B01111111,
    B11111000, B00000010, B00011111, B11111000, B01111111, B11110001, B11111111,
    B11100000, B10000000, B01000000, B00001000, B01001001, B00100001, B00000101,
    B10000000, B01000000, B00000000, B00000010, B00100000, B00000100, B10000000,
    B00001001, B00000000, B00000001, B00000000, B01000000, B00000100, B01001001,
    B00100000, B10000101, B01000000, B01000000, B00000000, B00000010, B01000000,
    B00000100, B10000000, B00001001, B00000000, B00000010, B00000000, B01000000,
    B00000000, B01001001, B00100000, B01000101, B00100000, B01000000, B00000000,
    B00000010, B00000000, B00000100, B10000000, B00001001, B00000000, B00000100,
    B00000000, B00111111, B11111000, B01001001, B00100000, B00100101, B00010000,
    B00100000, B00000111, B11111110, B00011111, B11111100, B11111111, B11111000,
    B10000000, B00000111, B11111111, B00000000, B00000100, B01001001, B00100000,
    B00010101, B00001000, B00010000, B00000000, B00000010, B00000000, B00000100,
    B10000000, B00001000, B01000000, B00000100, B00000000, B01000000, B00000100,
    B01001001, B00100000, B00001101, B00000100, B00001100, B00000000, B00000010,
    B01000000, B00000100, B10000000, B00001000, B00110000, B00000010, B00000000,
    B00100000, B00001000, B00110000, B11000011, B11111001, B00000010, B00000011,
    B00000000, B00000010, B00100000, B00000100, B10000000, B00001000, B00001100,
    B00000001, B00000000, B00011111, B11110000, B00000000, B00000000, B00000000,
    B00000000, B00000000, B11111000, B00000010, B00011111, B11111000, B00000000,
    B00000000, B00000011, B11100000, B10000000,
};

```

The bytes are arranged into rows of 7 each, each bit is literally 1 or 0.

Please make sure the image is already monochrome going in, this simply uses the value of "B" so it assumes you dithered it and did color reduction in a graphics program before running this utility.