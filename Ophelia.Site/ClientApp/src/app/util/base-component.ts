export class BaseComponent
{
  isVisible: boolean = false;
  message: string = "";
  type: string = "";
  id?: number;

  constructor()
  {
     
  }

  showInfo(message: string)
  {
    this.isVisible = true;
    this.type = 'info';
    this.message = message;
  }
  showError(message: string)
  {
    this.isVisible = true;
    this.type = 'error';
    this.message = message;
  }

}
