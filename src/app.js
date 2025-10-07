import express from 'express'
import { Router } from './routes/generalRoute.js';
import { PKRouter } from './routes/pkRoutes.js';
import { SaveRouter } from './routes/saveRoute.js';

export default class App {
    constructor() {
        this.server = express();
        this.server.use(express.json());

        const myRouter = new Router();
        const pkRouter = new PKRouter();
        const saveRouter = new SaveRouter();

        this.server.use('/api', myRouter.router)
        this.server.use('/api', pkRouter.router)
        this.server.use('/api', saveRouter.router)
    }
}