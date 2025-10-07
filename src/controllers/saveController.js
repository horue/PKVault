export class SaveController {
    static async addSave(req, res) {
        try {
            const recivedSave = req.file;
            if (!recivedSave){
                return res.status(400).send({ message: "No file recived." });
            }
            console.log(recivedSave)
        } catch (error) {
            
        }
        res.status(201).send({ message: "Save loaded!" });
    };
}
