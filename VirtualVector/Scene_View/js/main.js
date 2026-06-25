import * as THREE from 'three';
import { OrbitControls } from 'three/addons/controls/OrbitControls.js';
import { TransformControls } from 'three/addons/controls/TransformControls.js';
import { select } from 'three/src/nodes/math/ConditionalNode.js';

// var conts = await import("./stage.js");



let Builder = await chrome.webview.hostObjects.Builder;
let share = await chrome.webview.hostObjects.Share;


const raycaster = new THREE.Raycaster();
const pointer = new THREE.Vector2();





console.log(await share);

// import * as THREE from "three"

// let Builder = await chrome.webview.hostObjects.Builder;
// const executeString = new Function(await Builder.build());
// var h = eval(Builder.build());
// Execute the code
// const result = executeString();

// console.log(result)




// console.log(new THREE.BoxGeometry(1, 1, 1))


// await Builder.build();
// let script = document.createElement("script");

// script.append(Builder)

// async function injectCustomScript() {
//     const script = document.createElement('script');
//     script.innerHTML = `await import("./stage.js")`;
//     script.type = 'module';
//     script.async = false;
//     document.body.append(script);

// }

// Camera
const camera = new THREE.PerspectiveCamera(45, window.innerWidth / window.innerHeight, 0.1, 1000);
camera.position.set(5, 5, 5);
camera.lookAt(0, 0, 0);


// Renderer
const renderer = new THREE.WebGLRenderer({ antialias: true });
renderer.setSize(window.innerWidth, window.innerHeight);
renderer.shadowMap.enabled = true;
document.body.appendChild(renderer.domElement);
// camera.position.set(5, 5, 5);
// camera.lookAt(0, 0, 0);

// Controls
const controls = new OrbitControls(camera, renderer.domElement);
controls.enableDamping = true;
controls.dampingFactor = 0.05;
controls.autoRotate = false;
controls.enableZoom = true;
controls.update();
controls.addEventListener('change',render)

var transformControl = new TransformControls(camera, renderer.domElement)
transformControl.addEventListener('change',async  () => {
    render()
    console.log(await share.GetAll().length)
    // share.UpdateData(scene);
    // share.Update(1, scene);
    // window.postMessage("Test");
})
transformControl.addEventListener('dragging-changed', function (event) {

    controls.enabled = !event.value;

});







const scene = new THREE.Scene();
scene.background = new THREE.Color(0x1a1a2e);
scene.fog = new THREE.FogExp2(0x1a1a2e, 0.008);

const geometry = new THREE.BoxGeometry(1, 1, 1);
const material = new THREE.MeshBasicMaterial({ color: 0x00ff00 });
const yourObject3D = new THREE.Mesh(geometry, material);


// 2. Create the second camera
const camera2 = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);

// 3. Offset the camera locally so it isn't trapped inside the center of the object
camera2.position.set(0, 2, 5);
camera2.lookAt(yourObject3D.position);

// 4. Attach the camera directly to the object
yourObject3D.add(camera2); 

scene.add(yourObject3D); // <-- Crucial: The parent must be in the scene graph!
yourObject3D.position.set(1, 4, 0);
yourObject3D.name = "gamecameracontrolbox"
share.Add({ "gamecamera": yourObject3D })
// scene.add(gameCamera);

const ambientLight = new THREE.AmbientLight(0x404040);
scene.add(ambientLight);

// Main directional light
const directionalLight = new THREE.DirectionalLight(0xffffff, 1);
directionalLight.position.set(5, 10, 7);
directionalLight.castShadow = true;
directionalLight.receiveShadow = true;
scene.add(directionalLight);

// Fill light from below
const fillLight = new THREE.PointLight(0x4466cc, 0.3);
fillLight.position.set(0, -3, 0);
scene.add(fillLight);

// Back rim light
const rimLight = new THREE.PointLight(0xffaa44, 0.5);
rimLight.position.set(-2, 1, -3);
scene.add(rimLight);


var h = await Builder.build();
console.log(h)
const blob = new Blob([h], { type: 'text/javascript' });
const url = URL.createObjectURL(blob);
var data;

// 3. Dynamically import the module and use it
try {
    const dynamicModule = await import(url);
    console.log(dynamicModule); // Executes the function
    data = dynamicModule
    scene.add(data.main())
    // scene.add(dynamicModule.main())
} catch (error) {
    console.error("Failed to parse and inject script:", error);
} finally {
    // 4. Revoke the Object URL to free up memory
    URL.revokeObjectURL(url);
}

// // contentMain.main();

// console.log(typeof await Builder.build());

// Setup scene


// Lighting
// Ambient light


// Main object - a cool geometric shape
/*const geometry = new THREE.IcosahedronGeometry(1.2, 0);
const material = new THREE.MeshStandardMaterial({
    color: 0x3a86ff,
    metalness: 0.7,
    roughness: 0.3,
    emissive: 0x001133,
    flatShading: false
});
const mesh = new THREE.Mesh(geometry, material);
mesh.castShadow = true;
mesh.receiveShadow = true;
scene.add(mesh);

// Wireframe
const wireframeGeo = new THREE.IcosahedronGeometry(1.21, 0);
const wireframeMat = new THREE.MeshBasicMaterial({ color: 0x88ccff, wireframe: true, transparent: true, opacity: 0.3 });
const wireframeMesh = new THREE.Mesh(wireframeGeo, wireframeMat);
scene.add(wireframeMesh);
*/
// Ground grid
const gridHelper = new THREE.GridHelper(100000, 100000, 0x88aaff, 0x335588);
gridHelper.position.y = -1.5;
scene.add(gridHelper);

/*// Floating particles system
const particleCount = 1000;
const particlesGeometry = new THREE.BufferGeometry();
const positions = new Float32Array(particleCount * 3);
for (let i = 0; i < particleCount; i++) {
    positions[i * 3] = (Math.random() - 0.5) * 20;
    positions[i * 3 + 1] = (Math.random() - 0.5) * 10;
    positions[i * 3 + 2] = (Math.random() - 0.5) * 15 - 5;
}
particlesGeometry.setAttribute('position', new THREE.BufferAttribute(positions, 3));
const particlesMaterial = new THREE.PointsMaterial({ color: 0x44aaff, size: 0.05 });
const particles = new THREE.Points(particlesGeometry, particlesMaterial);
scene.add(particles);

// Small orbiting spheres
const orbitGroup = new THREE.Group();
const sphereGeo = new THREE.SphereGeometry(0.15, 16, 16);
const sphereMat = new THREE.MeshStandardMaterial({ color: 0xff6644, emissive: 0x441100 });
const orbitCount = 8;
const orbitSpheres = [];
for (let i = 0; i < orbitCount; i++) {
    const sphere = new THREE.Mesh(sphereGeo, sphereMat);
    const angle = (i / orbitCount) * Math.PI * 2;
    const radius = 2.5;
    sphere.position.x = Math.cos(angle) * radius;
    sphere.position.z = Math.sin(angle) * radius;
    sphere.userData = { angle, radius, speed: 0.5 + Math.random() * 0.5 };
    orbitGroup.add(sphere);
    orbitSpheres.push(sphere);
}
scene.add(orbitGroup);

// Animation variables
let time = 0;

// Expose functions to global scope for button callbacks
window.rotateCube = () => {
    mesh.rotation.x += 0.5;
    mesh.rotation.y += 0.5;
    wireframeMesh.rotation.copy(mesh.rotation);
};*/

// window.changeColor = () => {
//     const colors = [0x3a86ff, 0x8338ec, 0xf40666, 0xfb5607, 0xff006e, 0x00bbf9];
//     const newColor = colors[Math.floor(Math.random() * colors.length)];
//     mesh.material.color.setHex(newColor);
// };

const gizmo = transformControl.getHelper();
scene.add(gizmo);

window.addEventListener('pointermove', (event) => {
    // Calculates pointer position in normalized device coordinates
    // (-1 to +1) for both components
    pointer.x = (event.clientX / window.innerWidth) * 2 - 1;
    pointer.y = -(event.clientY / window.innerHeight) * 2 + 1;
});

window.addEventListener('click', () => {
    // Update the picking ray with the camera and pointer position
    raycaster.setFromCamera(pointer, camera);

    // Calculate objects intersecting the picking ray
    // Second parameter true checks all descendants recursively
    const intersects = raycaster.intersectObjects(scene.children, true);

    if (intersects.length > 0) {
        // The first element is always the closest object
        const selectedObject = intersects[0].object;

        console.log('Selected object:', selectedObject);
        transformControl.attach(selectedObject)

        // Example: Change the color of the selected object
        // selectedObject.material.color.set(0xff0000);
    }
});


window.resetCamera = () => {
    camera.position.set(5, 5, 5);
    camera.lookAt(0, 0, 0);
    controls.target.set(0, 0, 0);
    // controls.update();
};
share.Add(scene)
// scene.add(gameCamera);

function render() {
    // share.Update(1, scene);
    renderer.render(scene, camera);
}

// Animation loop
async function animate() {
    requestAnimationFrame(animate);
    // time += 0.008;

    // console.log(cube)
    // Rotate main mesh
    // mesh.rotation.y = time * 0.5;
    // mesh.rotation.x = Math.sin(time * 0.3) * 0.2;
    // wireframeMesh.rotation.copy(mesh.rotation);

    // Animate orbiting spheres
   /* orbitSpheres.forEach((sphere, idx) => {
        const speed = sphere.userData.speed;
        sphere.userData.angle += 0.01 * speed;
        const radius = sphere.userData.radius;
        sphere.position.x = Math.cos(sphere.userData.angle) * radius;
        sphere.position.z = Math.sin(sphere.userData.angle) * radius;
        sphere.position.y = Math.sin(sphere.userData.angle * 2) * 0.5;
    });

    // Rotate orbit group
    orbitGroup.rotation.y = time * 0.2;
    orbitGroup.rotation.x = Math.sin(time * 0.15) * 0.1;

    // Animate particles
    particles.rotation.y = time * 0.05;
    particles.rotation.x = Math.sin(time * 0.1) * 0.1;*/

    // Pulsing rim light
    // rimLight.intensity = 0.5 + Math.sin(time * 3) * 0.2;

    // Update controls and render
    // controls.update();
    render()
   
   
    
}



animate();
setTimeout(async () => {
    var items = await share.GetAll()

    console.log(items.length)

    // items = await share.GetAll()
    for (var i = 0; i < items.length; i++) {
        console.log(items[i]);
    }
    if (items.length > 0) {
        // console.log(await share.Update(1, scene));
    }
}, 4000)
// share.Add(scene)
// var items = await share.GetAll()
// setTimeout(() => {
    
//     console.log(items.length)
//     for (var i = 0; i < items.length; i++) {
//         console.log(items[i]);
//     }
// },2000)



// Handle window resize
window.addEventListener('resize', onWindowResize, false);
function onWindowResize() {
    camera.aspect = window.innerWidth / window.innerHeight;
    camera.updateProjectionMatrix();
    renderer.setSize(window.innerWidth, window.innerHeight);
}

// Log to C# when ready
console.log('Three.js engine initialized and ready!');
// await injectCustomScript();
