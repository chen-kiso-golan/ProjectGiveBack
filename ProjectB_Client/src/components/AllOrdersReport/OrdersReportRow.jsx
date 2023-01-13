import React, { useState, useEffect } from "react";
import { getAllOrdersFromDB } from "../../services/services";
import { UpdateOrderIsSentInDB } from "../../services/services";

export const OrdersReportRow = (props) => {
  const [AllOrders, setAllOrders] = useState([]);

  const getDB = async () => {
    let result = await getAllOrdersFromDB();
    setAllOrders(result.data);
  };

  useEffect(() => {
    getDB();
  }, []);

  const handelSendDonation = async (Order) => {
    await UpdateOrderIsSentInDB(Order);
    await getDB();
  };

  return (
    <>
      {AllOrders.length > 0 ? (
        AllOrders.map((Order) => {
          let { Code, SA_code, BC_code, Campaign_code, Product_code, Order_Time, Is_Sent } = Order;
          return (
            <>
              <tr>
                <th scope="row">{Code}</th>
                <td>{SA_code}</td>
                <td>{BC_code}</td>
                <td>{Campaign_code}</td>
                <td>{Product_code}</td>
                <td>{Order_Time}</td>
                <td>{Is_Sent ? "Sent" : "Not Sent"}</td>

                {!Is_Sent ? (
                  <td>
                    <button type="button" class="btn btn-primary" onClick={() => handelSendDonation(Order)}>
                      Send Donation
                    </button>
                  </td>
                ) : (
                  <td>Donation was Sent</td>
                )}
              </tr>
            </>
          );
        })
      ) : (
        <h1>There are no Orders.</h1>
      )}
    </>
  );
};
