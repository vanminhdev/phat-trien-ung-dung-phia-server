import io from 'socket.io-client';

// URL của máy chủ Socket.IO
const serverUrl = 'http://localhost:3000';

// Tạo một kết nối đến máy chủ
const socket = io(serverUrl);

socket.on('connect', () => {
    console.log('Connected to server');
});

socket.on('message', (message) => {
    console.log(message)
});

setInterval(() => {
    socket.emit("send-message", "hello")
}, 3000);

export default socket;