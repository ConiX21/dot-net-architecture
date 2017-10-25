import { AppProductsManagerPage } from './app.po';

describe('app-products-manager App', function() {
  let page: AppProductsManagerPage;

  beforeEach(() => {
    page = new AppProductsManagerPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
