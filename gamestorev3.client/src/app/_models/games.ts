import { GamePhoto } from "./gamephoto"

export interface Games{
  gameName: string
  MainPhoto: GamePhoto
  gameVersion: string
  price: number
  releaseDate: string
  photos: GamePhoto[]


}
