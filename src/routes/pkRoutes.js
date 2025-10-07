import express from 'express'
import { PKController } from '../controllers/pkController.js';



export class PKRouter {
    constructor() {
        this.router = express.Router()


        this.router.post('/pkmn/add', PKController.addPkmn);
    }
}