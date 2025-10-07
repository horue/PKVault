import mongoose from 'mongoose';

export class Mongo{
        static async connect(){
            try {
                mongoose.connect("mongodb://localhost:27017/pkvault")
                console.log("The aplication connected to the local database.")                
            } catch (error) {
                console.log("Error: " + error)          
                process.exit(1)      
            }
        }
}