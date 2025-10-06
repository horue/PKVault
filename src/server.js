import App from "./app.js";


class Server{
    static run() {
        const app = new App();
        const PORT = 151;
        app.server.listen(PORT, ()=> console.log('Server is running on port ' + PORT + "."));
    }
}

Server.run()