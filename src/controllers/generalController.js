export class GeneralController{
    static async connectionTest (req, res){
        const data = {
            message: "This is a connection test.",
            code: 200
        }
        res.json(data);
    };
}