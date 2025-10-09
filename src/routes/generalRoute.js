import express from 'express'
import { GeneralController } from '../controllers/generalController.js';




export class Router {
    constructor() {
        this.router = express.Router()


        this.router.get('/connection', GeneralController.connectionTest);
        this.router.get('/info', GeneralController.information);
        this.router.get('/temp', GeneralController.tempFolder);

    }
}