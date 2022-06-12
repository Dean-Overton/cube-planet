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
4) Create skin prefab as below.
5) In assets/skins/Start object add skinName, preview from above, actual prefab, and the requirements to unlock. 

WARNING: the requirements must be EITHER stars OR spaceJunk. One of these fields must be set to zero. TODO: resolve this issue.

### Animating/creating the new skin prefab

1) Sign up for https://www.mixamo.com/#/
2) "Upload character" and add your obj exported file from magica voxel.
3) Find the animations you want. At a minimum an idle and a walking animation is required. Previously used ones were "Strut walk" and "Happy idle".
4) Download as a "fbx file for unity" with skin.
5) Create a root gameObject for your new player skin prefab.
6) Add a collider (with no trigger), the player movement script, and rigidbody.
7) Copy the downloaded .fbx files from downloads into the unity project.
 assets/models/characters/animation/<new_skin_name>/
8) Click on each fbx file and do the following:
8.1) Navigate to 'rig' tab in inspector. Set 'animation type' to humanoid. Set 'avatar definition' to 'create from this model'. Apply changes.
8.2) Navigate to 'Animation' tab in inspector. Check 'Loop time', and all three 'Bake into pose' check boxes.
8.3) Navigate to 'Materials' tab in inspector. Set 'material creation mode' to 'standard legacy', set location to 'use embedded materials'.
Then click 'search and remmap'. And in the 'no name' tab drag the material from your original exported model from magica voxel.
9) Now drag these 2 animations into a new animator controller. Add triggers for is_walking in the transitions.
10) Drag the now changed fbx_idle asset as a child under your root gameobject that was created previously for the new player skin prefab.
11) Follow 'Add new skins' tutorial to make the skin selectable. 
