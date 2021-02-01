import { NotificationsResult } from "./notifications-result";

export class CommandResultError {
    constructor(
      public notifications?: NotificationsResult,
      public invalid?: boolean,
      public valid?: boolean
    ) {}
  
    static fromJson(jsonData: any): CommandResultError {
      return Object.assign(new CommandResultError(), jsonData);
    }
  }