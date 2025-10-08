import { exec } from 'child_process';
import chalk from 'chalk';


export class SaveController {
    static async addSave(req, res) {
        try {
            const exePath = "src\\utils\\PKVault\\bin\\Debug\\net9.0\\PKVault.exe";
            const recivedSave = req.file.path;
            exec(`${exePath} 3 "${recivedSave}"`, (error, stdout, stderr) => {
                if (error) {
                    console.error(`Erro: ${error.message}`);
                    return;
                }
                if (stderr) {
                    console.error(`Stderr: ${stderr}`);
                    return;
                }
                console.log(chalk.magentaBright('--- Start of C# console ---'))
                console.log(chalk.green(`${stdout}`));
                console.log(chalk.magentaBright('--- End of C# console ---'))
            });
            if (!recivedSave) {
                return res.status(400).send({ message: "No file recived." });
            }
            console.log(recivedSave)
            console.log("Getting pkmn from save file using C# dependecy...")
        } catch (error) {
            console.log("Error: " + error)
        }
        res.status(201).send({ message: "Save loaded and converted!" });
    };
}
