/*importScripts('/__/firebase/3.8.0/firebase-app.js');
importScripts('/__/firebase/3.8.0/firebase-messaging.js');
importScripts('/__/firebase/init.js');*/

/*importScripts('https://www.gstatic.com/firebasejs/4.8.1/firebase-app.js');
importScripts('https://www.gstatic.com/firebasejs/4.8.1/firebase-auth.js');
importScripts('https://www.gstatic.com/firebasejs/4.8.1/firebase-database.js');
importScripts('https://www.gstatic.com/firebasejs/4.8.1/firebase-firestore.js');
importScripts('https://www.gstatic.com/firebasejs/4.8.1/firebase-messaging.js');*/


/*importScripts('https://www.gstatic.com/firebasejs/4.8.1/firebase.js');
firebase.messaging();
*/

importScripts('https://www.gstatic.com/firebasejs/3.5.2/firebase-app.js');
importScripts('https://www.gstatic.com/firebasejs/3.5.2/firebase-messaging.js');

// TODO: fill in messaging sender id
firebase.initializeApp({
  'messagingSenderId': '129581670274'
});

const messaging = firebase.messaging();

// Installs service worker
self.addEventListener('install', (event) => {
  console.log('Service worker installed');
});

self.addEventListener('notificationclick', (event) => {
  // Event actions derived from event.notification.data from data received
  var eventURL = event.notification.data;
  event.notification.close();
  if (event.action === 'confirmAttendance') {
    clients.openWindow(eventURL.confirm);
  } else {
    clients.openWindow(eventURL.decline);
  }
}, false);

messaging.setBackgroundMessageHandler((payload) => {
  // Parses data received and sets accordingly
  const data = JSON.parse(payload.data.notification);
  const notificationTitle = data.title;
  const notificationOptions = {
    body: data.body,
    // icon: '/static/images/5/icons/android-icon-96x96.png',
    actions: [
      {action: 'confirmAttendance', title: '👍 Confirm attendance'},
      {action: 'cancel', title: '👎 Not coming'}
    ],
    // For additional data to be sent to event listeners, needs to be set in this data {}
    data: {confirm: data.confirm, decline: data.decline}
  };

  return self.registration.showNotification(notificationTitle, notificationOptions);
});
