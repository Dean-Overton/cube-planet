# Cube Planet

Inspiration:

<picture>
  <img alt="Inspiration" width="300" src="https://i.pinimg.com/originals/3c/f9/77/3cf9771d5a37818fca2f71da3ffa1e52.jpg">
</picture>
<picture>
  <img alt="Inspiration" width="300" src="https://i.pinimg.com/originals/66/39/7e/66397e869aa00f6a3a81eb525e61b28a.jpg">
</picture>
<picture>
  <img alt="Inspiration" width="300" src="https://i.pinimg.com/originals/c2/cd/f7/c2cdf71ca50f2760b84de9b1c836301b.jpg">
</picture>

### Add new level

1) Create Scene
2) Assets/Levels/*TheThemeTheLevelIs* - Add the scene name and level number
3) Add scene to File/BuildSettings 'ScenesInBuild'.

### Add new skins

1) Create Object in Magica voxel, (40x40x40 block preferably)

2) To get the skin preview image export as 'iso' from magica voxel.

3) Export as .obj into assets/models to get the 3D object.

4) Add player movement and create a prefab.

5) In assets/skins/Start object add skinName, preview from above, actual prefab, and the requirements to unlock. 

WARNING: the requirements must be EITHER stars OR spaceJunk. One of these fields must be set to zero. TODO: resolve this issue.