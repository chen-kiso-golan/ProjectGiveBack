import React from "react";
import "./AllOrdersReportStyle.css";

export function AllOrdersReport(props) {
  return (
    <table className="table">
      <thead>
        <tr>
          <th scope="col">ID</th>
          <th scope="col">Company</th>
          <th scope="col">Campaign</th>
          <th scope="col">Activist</th>
          <th scope="col">Sent</th>
          <th scope="col">Date Of Order</th>
        </tr>
      </thead>
      <tbody className="table-group-divider">
        <tr>
          <th scope="row">?</th>
          <td>?</td>
          <td>?</td>
          <td>?</td>
          <td>?</td>
          <td>?</td>
        </tr>
      </tbody>
    </table>
  );
}
