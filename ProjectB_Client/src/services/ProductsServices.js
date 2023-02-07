import axios from "axios";

const ServerAddress = "http://localhost:7205/api/Products";

export const getAllProductsFromDB = async () => {
  let endpoint = await axios.get(`${ServerAddress}/getAllProductsFromDB`);
  return endpoint;
};

export const addProductToDB = async (frm) => {
  console.log(frm);
  await axios.post(`${ServerAddress}/ProductPost`, frm);
  console.log("Product form was sent to DB :)");
};
