export default class EditorBus {
    constructor(name) {
        this.socket = new WebSocket("ws://localhost:5000");

        this.socket.onopen = () => {
            this.socket.send("REGISTER:" + name);
        };

        this.socket.onmessage = (e) => {
            let msg = JSON.parse(e.data);

            if (this.onmessage)
                this.onmessage(msg);
        };
    }

    postMessage(target, data) {
        this.socket.send(JSON.stringify({

            from: "",
            to: target,
            payload: data

        }));
    }
}