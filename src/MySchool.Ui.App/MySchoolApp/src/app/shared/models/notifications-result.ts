export class NotificationsResult {
    constructor(
      public property?: string,
      public message?: string,
    ) {}
  
    static fromJson(jsonData: any): NotificationsResult {
      return Object.assign(new NotificationsResult(), jsonData);
    }
  }