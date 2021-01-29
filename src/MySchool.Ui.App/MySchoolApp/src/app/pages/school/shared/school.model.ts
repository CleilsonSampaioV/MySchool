import { BaseResourceModel } from '../../../shared/models/base-resource.model';

export class School extends BaseResourceModel {
  constructor(
    public name?: string,
    public cnpj?: string,
    public street?: string,
    public number?: string,
    public neighborhood?: string,
    public city?: string,
    public state?: string,
    public country?: string,
    public zipCode?: string,
    public classes?: any,
    public notifications?: any,
    public invalid?: boolean,
    public valid?: boolean,
  ) {
    super();
  }


  static fromJson(jsonData: any): School {
    return Object.assign(new School(), jsonData);
  }
}
