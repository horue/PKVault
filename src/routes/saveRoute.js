import express from 'express'
import { SaveController } from '../controllers/saveController.js'
import { upload } from '../config/multer.js' 

export class SaveRouter {
    constructor() {
        this.router = express.Router()

        this.router.post('/save/add', upload.single("saveFile"), SaveController.addSave);
    }
}
