import express from 'express'
import { Router } from './routes/generalRoute.js';

export default class App{
    constructor(){
    this.server = express();
    this.server.use(express.json());

    const myRouter = new Router();

    this.server.use('/api', myRouter.router)
    }
}