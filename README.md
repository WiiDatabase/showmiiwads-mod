Mod of showmiiwads-mod
=======================
This is a modification of [showmiiwads-mod](https://code.google.com/archive/p/showmiiwads-mod/) by orwel. The original was coded by [Leathl](https://code.google.com/archive/p/showmiiwads/).

## Changelog
### v1.5.1
Important fixes to the WAD building process from NAND dumps:
* Tickets are not faked with the "beer ticket" anymore
* Removed footer
* Corrected certificates
  * They get written from the `cert-corrected.sys` file. It's included in the `ShowMiiWads` directory and must be copied next to the compiled EXE
* Fixed build process
