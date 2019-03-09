const staticCacheName = 'v1';



self.addEventListener('install', (event) => {
  self.skipWaiting();
  event.waitUntil(
    caches.open(staticCacheName)
    .then((cache) => {
        return cache.addAll([
            '/home/index',
            '/assets/js/imgloaded.js',
            '/assets/js/isotope.js',
            '/assets/js/jquery.counterup.min.js',
            '/assets/js/jquery.magnific-popup.min.js',
            '/assets/js/jquery.min.js',
            '/assets/js/main.js',
            '/assets/js/popper.js',
            '/assets/js/pw.js',
            '/assets/js/slick.min.js',
            '/assets/js/waypoints.min.js',
            '/assets/js/wow.min.js',
            '/assets/css/animate.min.css',
            '/assets/css/bootstrap.min.css',
            '/assets/css/et-line.css',
            '/assets/css/font-awesome.min.css',
            '/assets/css/ionicons.min.css',
            '/assets/css/magnific-popup.css',
            '/assets/css/main.css',
            '/assets/css/slick.css'

        ]);
    })
    .catch((error) => {
      console.log(`Error caching static assets: ${error}`);
    })
  );
});

self.addEventListener('activate', (event) => {
  if (self.clients && clients.claim) {
    clients.claim();
  }
  event.waitUntil(
    caches.keys().then((cacheNames) => {
      return Promise.all(
        cacheNames.filter((cacheName) => {
          return cacheName.startsWith('v') && cacheName !== staticCacheName;
        })
        .map((cacheName) => {
          return caches.delete(cacheName);
        })
      ).catch((error) => {
        console.log(`Some error occurred while removing existing cache: ${error}`);
      });
    }).catch((error) => {
      console.log(`Some error occurred while removing existing cache: ${error}`);
    }));
});

self.addEventListener('fetch', (event) => {
  event.respondWith(
    caches.match(event.request).then((response) => {
          return response || fetch(event.request);
    }).catch((error) => {
      console.log(`Some error occurred while saving data to dynamic cache: ${error}`);
    })
  );
});


self.addEventListener('push', function (e) {
    var options = {
        body: 'This notification was generated from a push!',
        icon: 'images/example.png',
        vibrate: [100, 50, 100]
    };
    e.waitUntil(
        self.registration.showNotification('Hello world!', options)
    );
});