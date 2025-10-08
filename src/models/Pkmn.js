import mongoose from "mongoose";

const PkmnSchema = new mongoose.Schema(
  {
    nickname: String,
    gender: Number,
    level: Number,
    species: Number,
    type1: String,
    type2: String,
    dexNumber: Number,
    originalTrainer: String,
    nature: String,
    data: Buffer
  },
  { timestamps: true }
);

const Pkmn = mongoose.model("Pkmn", PkmnSchema);
export default Pkmn;
