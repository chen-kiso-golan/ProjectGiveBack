import axios from "axios";

const ServerAddress = "http://localhost:7205/api/Orders";

export const getAllOrdersFromDB = async () => {
  let endpoint = await axios.get(`${ServerAddress}/getAllOrdersFromDB`);
  return endpoint;
};

export const addOrderToDB = async (frm) => {
  console.log(frm);
  await axios.post(`${ServerAddress}/OrderPost`, frm);
  console.log("Order form was sent to DB :)");
};

export const UpdateOrderIsSentInDB = async (Order) => {
  await axios.post(`${ServerAddress}/UpdateOrderIsSent`, Order);
};
