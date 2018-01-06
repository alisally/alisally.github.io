/*importScripts('/__/firebase/3.8.0/firebase-app.js');
importScripts('/__/firebase/3.8.0/firebase-messaging.js');
importScripts('/__/firebase/init.js');*/

/*importScripts('https://www.gstatic.com/firebasejs/4.8.1/firebase-app.js');
importScripts('https://www.gstatic.com/firebasejs/4.8.1/firebase-auth.js');
importScripts('https://www.gstatic.com/firebasejs/4.8.1/firebase-database.js');
importScripts('https://www.gstatic.com/firebasejs/4.8.1/firebase-firestore.js');
importScripts('https://www.gstatic.com/firebasejs/4.8.1/firebase-messaging.js');*/


/*importScripts('https://www.gstatic.com/firebasejs/4.8.1/firebase.js');
importScripts('https://www.gstatic.com/firebasejs/3.5.2/firebase-app.js');
importScripts('https://www.gstatic.com/firebasejs/3.5.2/firebase-messaging.js');
firebase.messaging();

https://github.com/firebase/friendlychat-web/issues/208
*/





importScripts('https://www.gstatic.com/firebasejs/4.8.1/firebase-app.js');
importScripts('https://www.gstatic.com/firebasejs/4.8.1/firebase-messaging.js');
importScripts('https://www.gstatic.com/firebasejs/4.8.1/firebase.js');


var config = {
apiKey: "AIzaSyD4_zMt8NByD4zsxQ8Ugw3NB9MrQN5vfiI",
        authDomain: "beautycenter-bb072.firebaseapp.com",
        databaseURL: "https://beautycenter-bb072.firebaseio.com",
        projectId: "beautycenter-bb072",
        storageBucket: "beautycenter-bb072.appspot.com",
        messagingSenderId: "129581670274"
};
firebase.initializeApp(config);
const messaging = firebase.messaging();

messaging.setBackgroundMessageHandler(function(payload) {
    console.log('[firebase-messaging-sw.js] Received background message ', payload);
    // Customize notification here
    const notificationTitle = 'Background Message Title';
    const notificationOptions = {
        body: 'Background Message body.',
        icon: '/firebase-logo.png'
    };

return self.registration.showNotification(notificationTitle,
    notificationOptions);
});




