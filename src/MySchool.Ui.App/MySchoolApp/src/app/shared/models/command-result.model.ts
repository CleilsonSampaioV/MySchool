export class CommandResult {
  constructor(
    public success?: boolean,
    public message?: string,
    public data?: any
  ) {}

  static fromJson(jsonData: any): CommandResult {
    return Object.assign(new CommandResult(), jsonData);
  }
}