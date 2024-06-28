import { GamePhoto } from "./gamephoto"

export interface Games{
  gameName: string
  gameVersion: string
  price: number
  releaseDate: string
  photos: GamePhoto[]


}
