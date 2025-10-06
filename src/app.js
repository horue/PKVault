import express from 'express'

export default class App{
    constructor(){
    this.server = express();
    this.server.use(express.json());
    }
}