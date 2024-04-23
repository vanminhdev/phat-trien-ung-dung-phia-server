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

// Xử lý sự kiện khi mất kết nối với máy chủ
socket.on('disconnect', () => {
    console.log('Disconnected from server');
});

setInterval(() => {
    socket.emit("send-message", "hello")
}, 3000);

export default socket;