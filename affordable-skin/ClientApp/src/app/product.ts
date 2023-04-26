export class Product
{
  id: number;
  image: string;
  name: string;
  link: string;
  lowestPrice: number;


  constructor() {
    this.id= -1
    this.image=""
    this.name = ""
    this.link = "";
    this.lowestPrice = 0;
  }
}
