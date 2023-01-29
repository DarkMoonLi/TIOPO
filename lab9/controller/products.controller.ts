import got from "got";
import { URLSearchParams } from "url";

export class ProductsController {
  async getAllProducts(): Promise<any> {
    const response = await got.get("http://shop.qatl.ru/api/products");
    try {
      response.body = JSON.parse(response.body);
    } catch { }
    return response;
  }

  async createProduct(data): Promise<any> {
    const response = await got.post("http://shop.qatl.ru/api/addproduct", {
      json: data
    });
    try {
      response.body = JSON.parse(response.body);
    } catch { }
    return response;
  }

  async editProduct(data): Promise<any> {
    const response = await got.post("http://shop.qatl.ru/api/editproduct", {
      json: data
    });
    try {
      response.body = JSON.parse(response.body);
    } catch { }
    return response;
  }

  async deleteProductById(id: string): Promise<any> {
    const response = await got.get(`http://shop.qatl.ru/api/deleteproduct?id=${id}`);
    try {
      response.body = JSON.parse(response.body);
    } catch { }
    return response;
  }
}