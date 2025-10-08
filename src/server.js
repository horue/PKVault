import App from "./app.js";
import { Mongo } from "./config/db.js";
import chalk from "chalk";


class Server {
    static async run() {
        Mongo.connect();

        const app = new App();
        const PORT = 151;

        console.log("--- About ---")
        console.log(chalk.blueBright('PKVault developed by horue.'))
        console.log(chalk.redBright('All Pokémon-related names, sprites, designs, and intellectual properties are the sole property of Nintendo, The Pokémon Company, Creatures Inc., and Game Freak.'));
        console.log("--- Info ---")
        app.server.listen(PORT, () => console.log(chalk.green('Server is running on port ' + PORT + ".")));
    }
}


await Server.run()