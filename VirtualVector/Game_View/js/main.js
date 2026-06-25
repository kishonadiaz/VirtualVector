import * as THREE from 'three';
import { OrbitControls } from 'three/addons/controls/OrbitControls.js';
var event = new Event("Launch");

let share = await chrome.webview.hostObjects.Share;
let items = await share.GetAll()
// setTimeout(async () => {
//     share = await chrome.webview.hostObjects.Share;
//     items = await share.GetAll()
//     console.log(items.length)
//     if (items.length > 0) {
//         window.dispatchEvent(event);
//         done = true;
//     }
// }, 2000)

const renderer = new THREE.WebGLRenderer({ antialias: true });
renderer.setSize(window.innerWidth, window.innerHeight);
renderer.shadowMap.enabled = true;
document.body.appendChild(renderer.domElement);
let gameCamera;
let done = false;
var meta = setInterval(async () => {
    if (done) return;
    setTimeout(async () => {
        share = await chrome.webview.hostObjects.Share;
        items = await share.GetAll()
        // console.log(items.length)
        if (items.length > 0) {
            // window.dispatchEvent(event);
            console.log(items[0].gamecamera.object)
            done = true;
            
            const loader = new THREE.ObjectLoader();
            const rebuiltScene = loader.parse(items[1]);
            

            // Search the rebuilt scene for the camera object
            rebuiltScene.traverse((child) => {

              
                if (child.isCamera) {
                    gameCamera = child;
                    console.log(gameCamera)
                }
                
            });
            renderer.render(rebuiltScene, gameCamera);
            clearInterval(meta);
        }
    }, 10)
    
},100)

window.addEventListener("launch", async () => {
    console.log(items.length)
})
window.addEventListener("message", (e) => {
    console.log(e.data);
})
async function render() {
    window.requestAnimationFrame(render);

    if (items == undefined) return
    console.log(items)
    
    // console.log(share.GetAll())
    // if(items.length <= 0) return
    // share.Update(1, items[1])

    // const loader = new THREE.ObjectLoader();
    // const rebuiltScene = loader.parse(items[1]);

    // rebuiltScene.traverse((child) => {


    //     if (child.isCamera) {
    //         gameCamera = child;
    //         console.log(gameCamera)
    //     }
    //     if (child.name == "gamecameracontrolbox") {
    //         console.log(child)
    //     }

    // });

    // renderer.render(rebuiltScene, gameCamera);

    // renderer.render(scene, camera);
    // if (items != undefined) {
    //     if (items.length <= 0) {
    //         share = await chrome.webview.hostObjects.Share;
    //         items = await share.GetAll()

    //     } else {
    //         if (items != undefined) {
    //             console.log(items.length)
    //         }

    //     }
    // } else {

    //     setTimeout(async () => {

    //         share = await chrome.webview.hostObjects.Share;
    //         items = await share.GetAll()

    //     }, 100)
    // }
    
    

    
    // var items = await share.GetAll()
    // console.log(items.length)
    // for (var i = 0; i < items.length; i++) {
    //     console.log(items[i]);
    // }
}

render();

// Setup scene
// const scene = new THREE.Scene();
// scene.background = new THREE.Color(0x1a1a2e);
// scene.fog = new THREE.FogExp2(0x1a1a2e, 0.008);

// Camera
// const camera = new THREE.PerspectiveCamera(45, window.innerWidth / window.innerHeight, 0.1, 1000);
// camera.position.set(5, 5, 5);
// camera.lookAt(0, 0, 0);

// Renderer
// const renderer = new THREE.WebGLRenderer({ antialias: true });
// renderer.setSize(window.innerWidth, window.innerHeight);
// renderer.shadowMap.enabled = true;
// document.body.appendChild(renderer.domElement);

// Controls
// const controls = new OrbitControls(camera, renderer.domElement);
// controls.enableDamping = true;
// controls.dampingFactor = 0.05;
// controls.autoRotate = false;
// controls.enableZoom = true;

// Lighting
// Ambient light
// const ambientLight = new THREE.AmbientLight(0x404040);
// scene.add(ambientLight);

// Main directional light
// const directionalLight = new THREE.DirectionalLight(0xffffff, 1);
// directionalLight.position.set(5, 10, 7);
// directionalLight.castShadow = true;
// directionalLight.receiveShadow = true;
// scene.add(directionalLight);

// Fill light from below
// const fillLight = new THREE.PointLight(0x4466cc, 0.3);
// fillLight.position.set(0, -3, 0);
// scene.add(fillLight);

// Back rim light
// const rimLight = new THREE.PointLight(0xffaa44, 0.5);
// rimLight.position.set(-2, 1, -3);
// scene.add(rimLight);

// Main object - a cool geometric shape
// const geometry = new THREE.IcosahedronGeometry(1.2, 0);
// const material = new THREE.MeshStandardMaterial({
//     color: 0x3a86ff,
//     metalness: 0.7,
//     roughness: 0.3,
//     emissive: 0x001133,
//     flatShading: false
// });
// const mesh = new THREE.Mesh(geometry, material);
// mesh.castShadow = true;
// mesh.receiveShadow = true;
// scene.add(mesh);

// Wireframe
// const wireframeGeo = new THREE.IcosahedronGeometry(1.21, 0);
// const wireframeMat = new THREE.MeshBasicMaterial({ color: 0x88ccff, wireframe: true, transparent: true, opacity: 0.3 });
// const wireframeMesh = new THREE.Mesh(wireframeGeo, wireframeMat);
// scene.add(wireframeMesh);

// Ground grid
// const gridHelper = new THREE.GridHelper(15, 20, 0x88aaff, 0x335588);
// gridHelper.position.y = -1.5;
// scene.add(gridHelper);

// Floating particles system
// const particleCount = 1000;
// const particlesGeometry = new THREE.BufferGeometry();
// const positions = new Float32Array(particleCount * 3);
// for (let i = 0; i < particleCount; i++) {
//     positions[i * 3] = (Math.random() - 0.5) * 20;
//     positions[i * 3 + 1] = (Math.random() - 0.5) * 10;
//     positions[i * 3 + 2] = (Math.random() - 0.5) * 15 - 5;
// }
// particlesGeometry.setAttribute('position', new THREE.BufferAttribute(positions, 3));
// const particlesMaterial = new THREE.PointsMaterial({ color: 0x44aaff, size: 0.05 });
// const particles = new THREE.Points(particlesGeometry, particlesMaterial);
// scene.add(particles);

// Small orbiting spheres
// const orbitGroup = new THREE.Group();
// const sphereGeo = new THREE.SphereGeometry(0.15, 16, 16);
// const sphereMat = new THREE.MeshStandardMaterial({ color: 0xff6644, emissive: 0x441100 });
// const orbitCount = 8;
// const orbitSpheres = [];
// for (let i = 0; i < orbitCount; i++) {
//     const sphere = new THREE.Mesh(sphereGeo, sphereMat);
//     const angle = (i / orbitCount) * Math.PI * 2;
//     const radius = 2.5;
//     sphere.position.x = Math.cos(angle) * radius;
//     sphere.position.z = Math.sin(angle) * radius;
//     sphere.userData = { angle, radius, speed: 0.5 + Math.random() * 0.5 };
//     orbitGroup.add(sphere);
//     orbitSpheres.push(sphere);
// }
// scene.add(orbitGroup);

// Animation variables
// let time = 0;

// Expose functions to global scope for button callbacks
// window.rotateCube = () => {
//     mesh.rotation.x += 0.5;
//     mesh.rotation.y += 0.5;
//     wireframeMesh.rotation.copy(mesh.rotation);
// };

// window.changeColor = () => {
//     const colors = [0x3a86ff, 0x8338ec, 0xf40666, 0xfb5607, 0xff006e, 0x00bbf9];
//     const newColor = colors[Math.floor(Math.random() * colors.length)];
//     mesh.material.color.setHex(newColor);
// };

// window.resetCamera = () => {
//     camera.position.set(5, 5, 5);
//     camera.lookAt(0, 0, 0);
//     controls.target.set(0, 0, 0);
//     controls.update();
// };

// Animation loop
// function animate() {
//     requestAnimationFrame(animate);
//     time += 0.008;

//     Rotate main mesh
//     mesh.rotation.y = time * 0.5;
//     mesh.rotation.x = Math.sin(time * 0.3) * 0.2;
//     wireframeMesh.rotation.copy(mesh.rotation);

//     Animate orbiting spheres
//     orbitSpheres.forEach((sphere, idx) => {
//         const speed = sphere.userData.speed;
//         sphere.userData.angle += 0.01 * speed;
//         const radius = sphere.userData.radius;
//         sphere.position.x = Math.cos(sphere.userData.angle) * radius;
//         sphere.position.z = Math.sin(sphere.userData.angle) * radius;
//         sphere.position.y = Math.sin(sphere.userData.angle * 2) * 0.5;
//     });

//     Rotate orbit group
//     orbitGroup.rotation.y = time * 0.2;
//     orbitGroup.rotation.x = Math.sin(time * 0.15) * 0.1;

//     Animate particles
//     particles.rotation.y = time * 0.05;
//     particles.rotation.x = Math.sin(time * 0.1) * 0.1;

//     Pulsing rim light
//     rimLight.intensity = 0.5 + Math.sin(time * 3) * 0.2;

//     Update controls and render
//     controls.update();
//     renderer.render(scene, camera);
// }

// animate();

// Handle window resize
// window.addEventListener('resize', onWindowResize, false);
// function onWindowResize() {
//     camera.aspect = window.innerWidth / window.innerHeight;
//     camera.updateProjectionMatrix();
//     renderer.setSize(window.innerWidth, window.innerHeight);
// }

// Log to C# when ready
// console.log('Three.js engine initialized and ready!');