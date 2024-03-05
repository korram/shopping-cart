import Image from "next/image";
import { Row, Col } from 'antd';
import ShoppingCart from "./../../components/shopping-cart";
export default function Home() {
  return (
    <main className="min-h-screen ">
      <ShoppingCart/>
     </main>
  );
}
