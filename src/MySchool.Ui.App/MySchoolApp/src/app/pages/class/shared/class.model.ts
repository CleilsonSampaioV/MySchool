import { Guid } from 'guid-typescript';

export class Class {
  constructor(
    public id?: Guid,
    public name?: string,
    public shift?: string,
    public degree?: string,
    public schoolId?: string,
    public School?: any,
    public notifications?: any,
    public invalid?: any,
    public valid?: any
  ) {}

  static fromJson(jsonData: any): Class {
    return Object.assign(new Class(), jsonData);
  }
}
