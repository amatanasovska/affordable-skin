export class Product
{
  key: number;
  image: string;
  name: string;
  brandName: string;
  lowestPrice: number;


  constructor() {
    this.key= -1
    this.image=""
    this.name = ""
    this.brandName = ""
    this.lowestPrice = 0;
  }
}
