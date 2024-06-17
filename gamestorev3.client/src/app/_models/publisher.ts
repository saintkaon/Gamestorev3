import { Games } from "./games";
import { User } from "./user";

export interface Publisher {
  user: User;
  games: Games[];
}
