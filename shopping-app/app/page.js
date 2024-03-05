import Image from "next/image";
import { Row, Col } from 'antd';
import ProductList from "./../components/product-list";
export default function Home() {
  return (
    <main className="min-h-screen ">
      <ProductList/>
     </main>
  );
}
