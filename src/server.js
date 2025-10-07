import App from "./app.js";
import { Mongo } from "./config/db.js";


class Server {
    static async run() {
        Mongo.connect();

        const app = new App();
        const PORT = 151;


        console.log('PKVault developed by horue.')
        console.log('All Pokémon-related names, sprites, designs, and intellectual properties are the sole property of Nintendo, The Pokémon Company, Creatures Inc., and Game Freak.');
        app.server.listen(PORT, () => console.log('Server is running on port ' + PORT + "."));
    }
}

await Server.run()