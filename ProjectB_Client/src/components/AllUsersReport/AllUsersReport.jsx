import React from "react";
import "./AllUsersReportStyle.css";
import { ActivistsReportRow, NpoReportRow, CompaniesReportRow } from "./ProductsReportRow";

export function AllProductsReport(props) {
  return (
    <>
      <h3>Activists:</h3>
      <table className="table">
        <thead>
          <tr>
            <th scope="col">Name</th>
            <th scope="col">Email</th>
            <th scope="col">Address</th>
            <th scope="col">PhoneNumber</th>
            <th scope="col">Money</th>
            <th scope="col">Campaign_code</th>
            <th scope="col">Image</th>
          </tr>
        </thead>
        <tbody className="table-group-divider">
          <ActivistsReportRow />
        </tbody>
      </table>
      <h3>Non Profit Organizations:</h3>
      <table className="table">
        <thead>
          <tr>
            <th scope="col">Name</th>
            <th scope="col">Email</th>
            <th scope="col">Website_URL</th>
            <th scope="col">Image</th>
          </tr>
        </thead>
        <tbody className="table-group-divider">
          <NpoReportRow />
        </tbody>
      </table>

      <h3>Companies:</h3>
      <table className="table">
        <thead>
          <tr>
            <th scope="col">Name</th>
            <th scope="col">Email</th>
            <th scope="col">Image</th>
          </tr>
        </thead>
        <tbody className="table-group-divider">
          <CompaniesReportRow />
        </tbody>
      </table>
    </>
  );
}
