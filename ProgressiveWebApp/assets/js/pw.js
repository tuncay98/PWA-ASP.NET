function urlBase64ToUint8Array(base64String) {
    const padding = '='.repeat((4 - base64String.length % 4) % 4);
    const base64 = (base64String + padding)
        .replace(/\-/g, '+')
        .replace(/_/g, '/')
        ;
    const rawData = window.atob(base64);
    return Uint8Array.from([...rawData].map((char) => char.charCodeAt(0)));
}

async function installServiceWorkerAsync() {
    if ('serviceWorker' in navigator) {
        try {
            let serviceWorker = await navigator.serviceWorker.register('/sw.js').then(function (reg) {
                console.log('Service Worker Registered!', reg);
                subscribeUserToPush()
            });

        } catch (err) {
            console.error(`Failed to register service worker: ${err}`);
        }
    }
}
installServiceWorkerAsync();

function askPermission() {
    return new Promise(function (resolve, reject) {
        const permissionResult = Notification.requestPermission(function (result) {
            resolve(result);
        });

        if (permissionResult) {
            permissionResult.then(resolve, reject);
        }
    })
        .then(function (permissionResult) {
            if (permissionResult !== 'granted') {
                throw new Error('We weren\'t granted permission.');


            }
        });
}

askPermission()



function subscribeUserToPush() {
    return navigator.serviceWorker.register('sw.js')
        .then(function (registration) {
            const subscribeOptions = {
                userVisibleOnly: true,
                applicationServerKey: urlBase64ToUint8Array(
                    'BMYfDOk7SYx2FKv39YeHpQVfWOwHMru1s460VbABNd3GJbyJ1fa4j4dyvqBwMwVix61Tsqo-payXeGLLuoKSFzI'
                )
            };

            return registration.pushManager.subscribe(subscribeOptions);
        })
        .then(function (pushSubscription) {
            console.log('Received PushSubscription: ', JSON.stringify(pushSubscription));
            return pushSubscription;
        });
}