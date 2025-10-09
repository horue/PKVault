import { tempPath } from "./saveController.js";


export class GeneralController {
    static async connectionTest(req, res) {
        const data = {
            message: "This is a connection test.",
        }
        res.status(200).send(data);
    };
    static async information(req, res) {
        const data = {
            message: "PKVault is a fan-made, non-commercial software project created solely for educational and research purposes. It is not affiliated with, endorsed by, or supported by Nintendo, Game Freak, or The Pokémon Company. All names, sprites, designs, and trademarks related to Pokémon remain the intellectual property of their respective owners. This project does not include, distribute, or reproduce any copyrighted game assets."
        };
        res.json(data);

    }
    static async tempFolder(req, res) {
        const data = {
            message: "Temp folder path:" + tempPath
        };
        res.json(data);

    }
}