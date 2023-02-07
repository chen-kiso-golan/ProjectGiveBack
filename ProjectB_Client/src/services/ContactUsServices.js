import axios from "axios";

const ServerAddress = "http://localhost:7205/api/ContactUs";

export const addFormToContactUs = async (frm) => {
  await axios.post(`${ServerAddress}/ContactUsPost`, frm);
  console.log("contactUs form was sent to DB :)");
};
