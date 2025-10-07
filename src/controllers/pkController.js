import Pkmn from "../models/Pkmn.js";

export class PKController {
    static async addPkmn(req, res) {
        try {
            const createdPkmn = await Pkmn.create(req.body);
            console.log('Created pkmn:', createdPkmn);
        } catch (error) {
            
        }
        res.status(201).send({ message: "Pkmn saved!" });
    };
    static async information(req, res) {
        const data = {
            message: "PKVault is a fan-made, non-commercial software project created solely for educational and research purposes. It is not affiliated with, endorsed by, or supported by Nintendo, Game Freak, or The Pokémon Company. All names, sprites, designs, and trademarks related to Pokémon remain the intellectual property of their respective owners. This project does not include, distribute, or reproduce any copyrighted game assets."
        };
        res.json(data);

    }
}